using ARAppBackend.DTOs.RestorePassword;
using ARAppBackend.Utils;
using Domain.Entities;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        public async Task<GetPasswordRestoreResponse> CreateCodeAsync(CreatePasswordRestoreRequest request)
        {

            GetPasswordRestoreResponse dto = new GetPasswordRestoreResponse();
            PasswordRestoreEntity entity = new PasswordRestoreEntity();

            var user = this._userDomainRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                throw new Exception("User does not exist!");
            }
            //Delete oldest code if exist
            var existsCode = this._passwordRestoreDomainRepository.GetCodeByUserId(user.Id);
            if (existsCode != null)
            {
                this._passwordRestoreDomainRepository.DeleteAllUserCodes(user.Id);
            }

            var code = await this.SendPasswordRecoveryEmailAsync(user.Email);
            if (code == null)
            {
                throw new Exception("Error sending restore password code!");
            }

            entity.UserId = user.Id;
            entity.Code = code;
            var codeId = await this._passwordRestoreDomainRepository.CreateCodeAsync(entity);

            dto.Id = codeId;
            dto.Code = code;
            dto.UserId = user.Id;

            return dto;
        }

        public bool VerifyCode(string email, string code)
        {

            var isCodeVerified = true;

            if (email == null || code == null)
            {
                throw new Exception("Email or code cannot be empty!");
            }
            var user = this._userDomainRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("User does not exist!");
            }

            var codeEntity = this._passwordRestoreDomainRepository.GetCodeByUserId(user.Id);
            if (codeEntity.Code != code)
            {
                isCodeVerified = false;
            }
            else
            {
                this._passwordRestoreDomainRepository.DeleteAllUserCodes(user.Id);
            }

            return isCodeVerified;
        }

        public bool ChangePassword(string email, string newPassword)
        {

            var isPasswordChanged = true;

            try
            {
                if (email == null || newPassword == null)
                {
                    isPasswordChanged = false;
                    throw new Exception("Email or New Password cannot be empty!");
                }
                var user = this._userDomainRepository.GetUserByEmail(email);
                if (user == null)
                {
                    isPasswordChanged = false;
                    throw new Exception("User does not exist!");
                }
                PasswordUtils.CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.UpdateDate = DateTime.Now;
                this._userDomainRepository.Update(user);

                return isPasswordChanged;
            }
            catch (Exception ex)
            {
                isPasswordChanged = false;
                throw ex;
            }

        }
    }
}
