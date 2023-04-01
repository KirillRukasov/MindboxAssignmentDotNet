# Введение

Есть две таблицы: Products и Categories, а также связующая таблица ProductCategories, которая хранит связи между продуктами и категориями.

Таблица Products:

ProductID (int, primary key)
ProductName (nvarchar)

Таблица Categories:

CategoryID (int, primary key)
CategoryName (nvarchar)

Таблица ProductCategories:

ProductID (int, foreign key)
CategoryID (int, foreign key)

# Задача

Выбор всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

# Решение

SQL запрос:

```
SELECT P.ProductName, C.CategoryName
FROM Products P
LEFT JOIN ProductCategories PC ON P.ProductID = PC.ProductID
LEFT JOIN Categories C ON PC.CategoryID = C.CategoryID
ORDER BY P.ProductName, C.CategoryName; 
```