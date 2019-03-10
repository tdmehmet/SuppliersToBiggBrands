using System.Linq;
using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;


namespace SuppliersToBiggBrands.Utils
{
    public static class ProductPictureMappingUtil
    {

        public static List<ProductPictureMapping> GenerateProductPictureMappings(string picturesString, List<Picture> pictures, Product product, 
            List<ProductPictureMapping> productPictureMappings)
        {
            string[] imageArray = picturesString?.Split('#');
            List<ProductPictureMapping> productPictureMappingList = new List<ProductPictureMapping>();
            int displayOrder = 0;

            if (imageArray != null)
            {
                foreach (string image in imageArray)
                {
                    Picture picture = pictures.Where(p => p.SeoFilename == image).FirstOrDefault();
                    if (picture == null)
                    {
                        picture = new Picture()
                        {
                            PictureBinary = null,
                            MimeType = "image/jpeg",
                            SeoFilename = image,
                            IsNew = false,
                        };

                    }
                    ProductPictureMapping productPictureMapping = productPictureMappingList
                        .Where(ppm=> ppm.PictureId == picture.Id && ppm.ProductId == product.Id).FirstOrDefault();

                    if(productPictureMapping == null) { 
                        productPictureMappingList.Add(new ProductPictureMapping()
                        {
                            ProductId = product.Id,
                            PictureId = picture.Id,
                            DisplayOrder = displayOrder,
                            Product = product,
                            Picture = picture
                        });
                    }else
                    {
                        productPictureMappingList.Add(productPictureMapping);
                    }
                    displayOrder++;
                }
            }
            return productPictureMappingList;
        }
    }
}
