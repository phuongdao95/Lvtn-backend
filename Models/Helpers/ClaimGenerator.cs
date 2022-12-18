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

            "salary_delta",
            "salary_formula",
            "salary_group",
            "taskbaord",
            "payroll",
            "payslip",
            "task",
            "board",
        };

        public static readonly List<string> PageAccessClaims = new List<string>
        {
            "approve_workflow_list",
            "approve_workflow_config_list",
            "my_requests",
            "my_todo_requests",
            "user_nghi_phep",
            "user_nghi_thai_san",
            "user_check_in_out",
            "config_nghi_phep",
            "config_nghi_thai_san",
            "config_check_in_out",
            "user_nghi_phep_view",
            "user_nghi_thai_san_view",
            "user_check_in_out_view",
            "user_nghi_phep_todo",
            "user_nghi_thai_san_todo",
            "user_check_in_out_todo",

            "user_list",
            "role_list",
            "permission_list",
            "team_list",
            "group_list",
            "department_list",

            "taskboard_list",
            "taskboard_detail",
            "taskboard_label_list",
            "taskboard_column_list",
            "taskboard_report",

            "image_registration",
            "timekeeping_schedule",
            "workingshift_registration",
            "workingshift",
            "registered_workingshift",
            "workingshift_dayconfig",

            "salary_list",
            "dab_list",
            "formula_variable_list",
            "payroll_list",
            "payroll_detail",
            "payslip_detail",
            "salary_group_list",
            "my_payslip",
            "my_payslip_detail",
            "salary_report",

            "profile",
        };

        public static List<string> AdminUserPageAccessClaims = new List<string>
        {
            "approve_workflow_list",
            "approve_workflow_config_list",
            "my_requests",
            "my_todo_requests",
            "user_nghi_phep",
            "user_nghi_thai_san",
            "user_check_in_out",
            "config_nghi_phep",
            "config_nghi_thai_san",
            "config_check_in_out",
            "user_nghi_phep_view",
            "user_nghi_thai_san_view",
            "user_check_in_out_view",
            "user_nghi_phep_todo",
            "user_nghi_thai_san_todo",
            "user_check_in_out_todo",

            "user_list",
            "role_list",
            "permission_list",
            "team_list",
            "group_list",
            "department_list",

            "taskboard_list",
            "taskboard_detail",
            "taskboard_label_list",
            "taskboard_column_list",
            "taskboard_report",

            "image_registration",
            "timekeeping_schedule",
            "workingshift_registration",
            "workingshift",
            "registered_workingshift",
            "workingshift_dayconfig",

            "salary_list",
            "dab_list",
            "formula_variable_list",
            "payroll_list",
            "payroll_detail",
            "payslip_detail",
            "salary_group_list",
            "my_payslip",
            "my_payslip_detail",
            "salary_report",

            "profile",
        };

        public static List<string> NormalUserPageAccessClaims = new List<string>
        {
            "approve_workflow_list",
            "approve_workflow_config_list",
            "my_requests",
            "my_todo_requests",
            "user_nghi_phep",
            "user_nghi_thai_san",
            "user_check_in_out",
            "config_nghi_phep",
            "config_nghi_thai_san",
            "config_check_in_out",
            "user_nghi_phep_view",
            "user_nghi_thai_san_view",
            "user_check_in_out_view",
            "user_nghi_phep_todo",
            "user_nghi_thai_san_todo",
            "user_check_in_out_todo",

            "profile",
            "my_payslip",
            "my_payslip_detail",
            "image_registration",
            "timekeeping_schedule",
            "workingshift_registration",
            "registered_workingshift",

            "taskboard_list",
            "taskboard_detail",
            "taskboard_label_list",
            "taskboard_column_list",
            "taskboard_report",
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
            return $"{page}";
        }


        private static string generateResourceClaimNameForModule(string module, string action)
        {
            return $"{module}.{action}";
        }

        public static List<string> GeneratePageAccessClaimsForAdminUser()
        {
            return AdminUserPageAccessClaims.Select(name => generatePageAccessClaimName(name)).ToList();
        }

        public static List<string> GenerateResourceAccessClaimsForAdminUser()
        {
            return GenerateResourceAccessClaims();
        }

        public static List<string> GenerateResourceAccessClaimsForNormalUser()
        {
            return GenerateResourceAccessClaims();
        }

        public static List<string> GeneratePageAccessClaimsForNormalUser()
        {
            return NormalUserPageAccessClaims.Select(name => generatePageAccessClaimName(name)).ToList();
        }
    }
}
