# Exercise: Passing Parameters with Product Example

## Goal:
Your task is to add the ability to filter products based on parameters passed through the Query String. Additionally, there should be an option to display the product details page.

## Functional Requirements:

### 1. Product Detail Page (ProductDetail.razor):
- This page displays the details of a product based on the **route parameter** (`productId`).
- The page also supports the **query string**, which may contain an optional discount parameter, e.g., `?discount=true`.

### 2. Product List Page (ProductList.razor):
- The main page contains a list of products, from which the user can navigate to the product details.
- Each "Details" button redirects the user to the product detail page, passing the route parameter (`productId`) and the query string (discount).

Example URLs:

`/products?color=red` — shows products in red color

`/products?1?discount=true` — shows discounted price.

`/products/2?discount=false` — shows price without discount.

`/products/3` — shows the default price, no discount.