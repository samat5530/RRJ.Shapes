SELECT Products.Name, Categories.Name
FROM Products
LEFT JOIN ProductCategories
	ON Products.Id = ProductCategories.ProductId
LEFT JOIN Categories C
	ON ProductCategories.CategoryId = Categories.Id;