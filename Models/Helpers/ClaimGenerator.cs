namespace Models.Helpers
{
    public static class ClaimGenerator
    {

        public static readonly List<string> ModuleNames = new List<string>
        {
            "user",
            "role",
            "permission",
            "team",
            "department",
            "group",

            "dab",
            "salary_formula",
            "salary_variable",
            "payroll",
            "payslip",
            "task",
            "board",

        };

        public static readonly List<string> PageAccessClaims = new List<string>
        {
            "my_profile",
            "user_list",
            "role_list",
            "permission_list",
            "team_list",
            "group_list",
            "department_list",

            "dab_list",
            "my_dab",
            "my_payslip",
            "salary_formula_list",
            "salary_variable_list",
            "salary_group_list",
            "payroll_list",

            "board_list",
            "task_list",
            "board_list_of_team",
            "task_list_of_board",
            "label_list_of_board",

            "timekeeping_image_registration",
            "timekeeping_check_in",
            "timekeeping_check_out",
            "timekeeping_list",
            "workingshift_list",
        };

        public static List<string> AdminUserPageAccessClaims = new List<string>
        {
            "user_list",
            "role_list",
            "permission_list",
            "team_list",
            "group_list",
            "department_list",

            "dab_list",
            "salary_formula_list",
            "salary_variable_list",
            "salary_group_list",
            "payroll_list",
            "board_list",
            "task_list",

            "timekeeping_list",
            "workingshift_list",
        };

        public static List<string> NormalUserPageAccessClaims = new List<string>
        {
            "my_dab",
            "my_payslip",
            "board_list_of_team",
            "task_list_of_board",
            "label_list_of_board",
            "timekeeping_image_registration",
            "timekeeping_check_in",
            "timekeeping_check_out",
        };

        public static List<string> GenerateResourceAccessClaims()
        {
            var result = new List<string> { };
            ModuleNames.ForEach((module) =>
            {
                result.AddRange(generateResourceClaimsForModule(module));
            });

            return result;
        }

        private static List<string> generateResourceClaimsForModule(string module)
        {
            return new List<string>()
            {
                generateResourceClaimNameForModule(module, "create"),
                generateResourceClaimNameForModule(module, "retrieve"),
                generateResourceClaimNameForModule(module, "update"),
                generateResourceClaimNameForModule(module, "delete")
            };
        }

        public static List<string> GeneratePageAccessClaims()
        {
            return PageAccessClaims.Select(name => generatePageAccessClaimName(name)).ToList();
        }

        private static string generatePageAccessClaimName(string page)
        {
            return $"page_access.{page}";
        }

      
        private static string generateResourceClaimNameForModule(string module, string action)
        {
            return $"resource.{module}.{action}";
        }

        public static List<string> GeneratePageAccessClaimsForAdminUser()
        {
            return AdminUserPageAccessClaims.Select(name => generatePageAccessClaimName(name)).ToList();
        }

        public static List<string> GeneratePageAccessClaimsForNormalUser()
        {
            return NormalUserPageAccessClaims.Select(name => generatePageAccessClaimName(name)).ToList();
        }
    }
}
