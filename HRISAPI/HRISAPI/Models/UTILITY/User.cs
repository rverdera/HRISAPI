namespace HRISAPI.Models.UTILITY
{
    [Table("User", Schema = "UTILITY")]
    public class User : BaseModel
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? VerificationToken { get; set; } = string.Empty;
        [Column(TypeName = "datetime")]
        public DateTime? VerifiedAtTime { get; set; } = null;
        public string? PasswordResetToken { get; set; } = string.Empty;
        [Column(TypeName = "datetime")]
        public DateTime? ResetTokenExpires { get; set; } = null;
    }
}
