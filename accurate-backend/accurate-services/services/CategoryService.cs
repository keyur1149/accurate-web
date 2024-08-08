using accurate_data_access.DTO;
using accurate_data_access.Entities;
using accurate_data_access.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace accurate_services.services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse<List<CategoryTbl>>> FetchAllCategories()
        {
            APIResponse<List<CategoryTbl>> response = new APIResponse<List<CategoryTbl>>();
            try
            {
                List<CategoryTbl> categoryList =await  _unitOfWork.Category.Where(x => true).ToListAsync();
                categoryList.ForEach(category => category.CategoryImage = GetImagebyCategory(category.CategoryImage));
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = categoryList;
                response.ErrorMessages.Clear();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add(ex.Message);
                response.Result = null;
            }

            return response;
        }

        public async Task<APIResponse<string>> AddCategoryAsync(AddCategoryDTOs category)
        {
            APIResponse<string> response = new APIResponse<string>();
            try
            {
                bool categoryExits = await _unitOfWork.Category.AnyAsync(x => x.CategoryName.ToLower().Equals(category.Name.ToLower()));
                if (categoryExits)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Result = null;
                    response.ErrorMessages = new List<string> { "Category Name Already Exists." };
                }
                Tuple<bool, string> fileUpload = HelperStatic.UploadFile(category.Image);
                if (!fileUpload.Item1)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Result = null;
                    response.ErrorMessages = new List<string> { "Image Uploading problem." };
                }
                CategoryTbl newCategory = new CategoryTbl
                {
                    CategoryName = category.Name,
                    CategoryImage = fileUpload.Item2,
                };
                await _unitOfWork.Category.AddAsync(newCategory);
                await _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.Created;
                response.Result = null;
                response.ErrorMessages.Clear();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add(ex.Message);
                response.Result = null;
            }

            return response;
        }

        public async Task<APIResponse<string>> EditCategoryAsync(long categoryId, EditCategoryDTOs category)
        {
            APIResponse<string> response = new APIResponse<string>();
            try
            {
                bool categoryIdExits = await _unitOfWork.Category.AnyAsync(x => x.CategoryId.Equals(categoryId));
                if (!categoryIdExits)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Result = null;
                    response.ErrorMessages = new List<string> { "Category Not Exists." };
                }
                bool categoryExits = await _unitOfWork.Category.AnyAsync(x => !x.CategoryId.Equals(categoryId) && x.CategoryName.ToLower().Equals(category.Name.ToLower()));
                if (categoryExits)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Result = null;
                    response.ErrorMessages = new List<string> { "Category Name Already Exists." };
                }
                CategoryTbl? oldCategory = await _unitOfWork.Category.GetFirstOrDefault(x => x.CategoryId.Equals(categoryId));
                oldCategory.CategoryName = category.Name;
                if (category?.Image != null)
                {
                    Tuple<bool, string> fileUpload = HelperStatic.UploadFile(category?.Image);
                    if (!fileUpload.Item1)
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Result = null;
                        response.ErrorMessages = new List<string> { "Image Uploading problem." };
                    }
                    oldCategory.CategoryImage = fileUpload.Item2;
                }
                _unitOfWork.Category.Update(oldCategory);
                await _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = null;
                response.ErrorMessages.Clear();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add(ex.Message);
                response.Result = null;
            }

            return response;
        }

        public async Task<APIResponse<string>> RemoveCategoryAsync(long categoryId)
        {
            APIResponse<string> response = new APIResponse<string>();
            try
            {
                bool categoryIdExits = await _unitOfWork.Category.AnyAsync(x => x.CategoryId.Equals(categoryId));
                if (!categoryIdExits)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Result = null;
                    response.ErrorMessages = new List<string> { "Category Not Exists." };
                }

                CategoryTbl? oldCategory = await _unitOfWork.Category.GetFirstOrDefault(x => x.CategoryId.Equals(categoryId));


                _unitOfWork.Category.Delete(oldCategory);
                await _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = null;
                response.ErrorMessages.Clear();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add(ex.Message);
                response.Result = null;
            }

            return response;
        }

        #region helpers
        public string GetImagebyCategory(string category)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "https://localhost:44388/";
            string Filepath = HostUrl + "/uploads/category/" + category;
            if (!System.IO.File.Exists(Filepath))
            {
                ImageUrl = HostUrl + "/uploads/default/category/" + "";
            }
            else
            {
                ImageUrl = HostUrl + "/uploads/category/" + category;
            }
            return ImageUrl;
        }
        #endregion
    }
}
