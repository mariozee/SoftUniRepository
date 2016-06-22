using LearningSystem.Models;

namespace LearningSystem.Utilities
{
    public static class UserRoleUtilities
    {
        public static bool IsInRole(this User user, Role role)
        {
            bool isInRole = user != null && user.Role == role;

            return isInRole;
        }
    }
}
