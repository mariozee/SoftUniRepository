namespace Blob.Core
{
    public static class EngineMessages
    {
        #region EVENTS
        public static string OnBlobDeath = "Blob {0} was killed";
        public static string OnBehaviorChange = "Blob {0} toggled {1}";
        #endregion

        #region EXCEPTIONS
        public static string CannotAttackItself = "Blob cannot attack itself";
        public static string CannotAttackWithDeadBlob = "Cannnot attack with dead blob";
        public static string CannotAttackDeadBlob = "Cannot attack dead blob";
        public static string CannotFindBlobByName = "Blob with the name \"{0}\" doesnt exists";
        public static string NotImplemented = "{0} is not implemented yet";
        public static string MustBePositive = "{0} must be positive integer";
        public static string StringLengthOutOfRange = "{0} must be {1} or more symbols long";
        public static string SameBehaviorToggleErrorMsg = "Cannot apply same behaviour twice";

        #endregion

        #region BLOB_PRINT_STRINGS

        public static string AliveBlobPrintString = "Blob {0}: {1} HP, {2} Damage";

        #endregion
    }
}
