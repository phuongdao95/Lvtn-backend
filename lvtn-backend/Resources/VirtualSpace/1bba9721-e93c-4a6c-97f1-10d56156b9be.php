<?php

/*
 * This file is part of SoFi TS.
 *
 * (c) thinkstep AG (thinkstep.com)
 */

namespace App\SoFi\Tree\Model\Operation\Helper;

use App\SoFi\Model\HistorizedTree;
use App\ThinkStep\Db\Doctrine\Connection;

// use App\ThinkStep\Db\ConnectionInterface;

/**
 * An abstract base helper class.
 */
abstract class HelperAbstract
{
    private const SITE = 'site';

    /**
     * The database connection.
     *
     * @var Connection
     */
    protected $connection;

    /**
     * The master table name.
     *
     * @var string
     */
    protected $masterTable;

    /**
     * The index table name.
     *
     * @var string
     */
    protected $indexTable;

    /**
     * All related tables.
     *
     * @var array
     */
    protected $tables;

    /**
     * The primary key columns for all tables.
     *
     * @var array
     */
    protected $pkColumns;

    /**
     * The term start column.
     *
     * @var string
     */
    protected $termStartColumn;

    /**
     * The term end column.
     *
     * @var string
     */
    protected $termEndColumn;

    /**
     * The id column.
     *
     * @var string
     */
    protected $idColumn;

    /**
     * The parent id column.
     *
     * @var string
     */
    protected $parentIdColumn;

    /**
     * The parent term start column.
     *
     * @var string
     */
    protected $parentTermStartColumn;

    /**
     * Factory.
     *
     * @param HistorizedTree $model The model
     *
     * @return HelperAbstract
     */
    public static function fromModel(HistorizedTree $model)
    {
        return new static(
            $model->db(),
            $model->dbTableName(),
            $model->dbIndexTableName(),
            $model->dbTableColumns(),
            $model->dbTablePkColumns(),
            $model->termStartColumn(),
            $model->termEndColumn(),
            $model->idColumn(),
            $model->parentIdColumn(),
            $model->parentTermStartColumn()
        );
    }

    /**
     * Constructor.
     *
     * @param Connection $connection            The database connection
     * @param string     $masterTable           The master table
     * @param string     $indexTable            The index table
     * @param array      $tables                The table list (including columns)
     * @param array      $pkColumns             The primary key columns for all tables
     * @param string     $termStartColumn       The term start column
     * @param string     $termEndColumn         The term end column
     * @param string     $idColumn              The id column
     * @param string     $parentIdColumn        The parent id column
     * @param string     $parentTermStartColumn The parent term start column
     */
    public function __construct(
        Connection $connection,
        $masterTable,
        $indexTable,
        array $tables,
        array $pkColumns,
        $termStartColumn,
        $termEndColumn,
        $idColumn,
        $parentIdColumn,
        $parentTermStartColumn
    ) {
        $this->connection = $connection;
        $this->masterTable = $masterTable;
        $this->indexTable = $indexTable;
        $this->tables = $tables;
        $this->pkColumns = $pkColumns;
        $this->termStartColumn = $termStartColumn;
        $this->termEndColumn = $termEndColumn;
        $this->idColumn = $idColumn;
        $this->parentIdColumn = $parentIdColumn;
        $this->parentTermStartColumn = $parentTermStartColumn;
    }

    /**
     * Returns the database connection.
     *
     * @return Connection
     */
    protected function connection()
    {
        return $this->connection;
    }

    /**
     * Returns the master table name.
     *
     * @return string
     */
    protected function masterTable()
    {
        return $this->masterTable;
    }

    /**
     * Returns the index table name.
     *
     * @return string
     */
    protected function indexTable()
    {
        return $this->indexTable;
    }

    /**
     * Returns an array of defined tables.
     *
     * @return array
     */
    protected function tables()
    {
        return array_keys($this->tables);
    }

    /**
     * Returns the columns for a given table.
     *
     * @param string $table The table name
     *
     * @return array
     */
    protected function tableColumns($table)
    {
        if (array_key_exists($table, $this->tables)) {
            return array_keys($this->tables[$table]);
        } else {
            return [];
        }
    }

    /**
     * Returns the names of the defined primary key.
     *
     * @param string|null $table The table name or null for the master table
     *
     * @return array
     */
    protected function primaryKeyNames($table = null)
    {
        $table = $table ?: $this->masterTable();
        if (array_key_exists($table, $this->pkColumns)) {
            return $this->pkColumns[$table];
        } else {
            return [];
        }
    }

    /**
     * Returns the term start column.
     *
     * @return string
     */
    protected function termStartColumn()
    {
        return $this->termStartColumn;
    }

    /**
     * Returns the term end column.
     *
     * @return string
     */
    protected function termEndColumn()
    {
        return $this->termEndColumn;
    }

    /**
     * Returns the id column.
     *
     * @return string
     */
    protected function idColumn()
    {
        return $this->idColumn;
    }

    /**
     * Returns the parent id column.
     *
     * @return string
     */
    protected function parentIdColumn()
    {
        return $this->parentIdColumn;
    }

    /**
     * Returns the parent term start column.
     *
     * @return string
     */
    protected function parentTermStartColumn()
    {
        return $this->parentTermStartColumn;
    }

    /**
     * Returns an array with the primary key.
     *
     * @param array|null  $row   The database row
     * @param string|null $table The table name or null for the master table
     *
     * @return array
     */
    protected function extractPrimaryKeys(array $row = null, $table = null)
    {
        $pkNames = $this->primaryKeyNames($table);
        if (null === $row) {
            return array_combine($pkNames, array_fill(0, count($pkNames), null));
        }

        return array_intersect_key($row, array_combine($pkNames, $pkNames));
    }

    /**
     * Fixed the path column.
     *
     * @param array $newPrimaryKey The new primary key
     * @param bool  $recursive     True to run the path update recursively
     */
    protected function fixPath(array $newPrimaryKey)
    {
        $db = $this->connection();
        /* @todo DB-Refactoring */
        $query = sprintf(
            'SELECT path FROM %s WHERE (%s, %s) = (SELECT %s, %s FROM %s WHERE %s)',
            $this->masterTable(),
            $this->idColumn(),
            $this->termStartColumn(),
            $this->parentIdColumn(),
            $this->parentTermStartColumn(),
            $this->masterTable(),
            implode(
                ' AND ',
                array_map(
                    function ($k) {
                        return $k.' = :'.$k;
                    },
                    array_keys($newPrimaryKey)
                )
            )
        );
        $parentPath = $db->fetchColumn($query, $newPrimaryKey);
        if (empty($parentPath)) {
            $parentPath = '/';
        }

        $subQuery = sprintf('
            WITH RECURSIVE cte (site_id, term_start, parent_site_id, parent_term_start, new_path) as (
                SELECT  site_id,
                        term_start,
                        parent_site_id,
                        parent_term_start,
                        CAST(site_id AS CHAR(1000)) AS new_path
                FROM    site
                WHERE   site_id = :siteId AND
                        term_start = :termStart
                UNION ALL
                SELECT  s.site_id,
                        s.term_start,
                        s.parent_site_id,
                        s.parent_term_start,
                        CONCAT(cte.new_path, \'/\', s.site_id) AS new_path
                FROM    site s
                INNER JOIN cte
                        on s.parent_site_id = cte.site_id AND
                        s.term_start = cte.term_start
            )
            SELECT site_id, term_start, parent_site_id, parent_term_start, new_path FROM cte'
        );

        $query = '
            UPDATE site s1 
            LEFT JOIN (
                SELECT  site_id, 
                        term_start, 
                        CONCAT(new_path, \'/\') AS new_path 
                FROM ('.$subQuery.') AS temp 
            ) s2 

            ON  s1.site_id = s2.site_id AND 
                s1.term_start = s2.term_start
            SET s1.path = CONCAT(:parent_path, s2.new_path),
                s1.processed_path = process_site_path(s1.path)
            WHERE   s1.site_id = s2.site_id AND 
                    s1.term_start = s2.term_start
        ';

        $db->executeUpdate($query, [
            'parent_path' => $parentPath, 
            'siteId' => $newPrimaryKey['site_id'], 
            'termStart' => $newPrimaryKey['term_start'] ]
        );
    }
}
