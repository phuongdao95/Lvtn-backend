namespace Models.Helpers
{
    public static class ClaimGenerator
    {

        public static readonly List<string> moduleNames = new List<string>
        {
            "role",
            "permission",
            "team",
            "department",
            "group",

            "dab",
            "formula",
        };


        public static List<string> GenerateClaims()
        {
            var result = new List<string> { };
            moduleNames.ForEach((module) =>
            {
                result.AddRange(generateCRUDClaimForModule(module));
            });

            generateClaimNameForModule("user", "assign_to_team");

            return result;
        }

        private static List<string> generateCRUDClaimForModule(string module)
        {
            return new List<string>
            {
                generateClaimNameForModule(module, "create"),
                generateClaimNameForModule(module, "retrieve"),
                generateClaimNameForModule(module, "update"),
                generateClaimNameForModule(module, "delete")
            };
        }
        private static string generateClaimNameForModule(string module, string action)
        {
            return $"{module}.{action}";
        }
    }
}
