# Exercise: Refactoring the NavMenu.razor Component in Blazor

## Goal:
Refactor the existing `NavMenu.razor` component in a Blazor application by creating a reusable `MenuItem` component. The goal is to simplify the structure of the navigation menu and improve its readability and flexibility.

## Problem Description:
The current code in `NavMenu.razor` contains repetitive menu items in the following form:

```html
<div class="nav-item px-3">
    <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
        <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Home
    </NavLink>
</div>
<div class="nav-item px-3">
    <NavLink class="nav-link" href="customers">
        <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Customers
    </NavLink>
</div>
<div class="nav-item px-3">
    <NavLink class="nav-link" href="products">
        <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Products
    </NavLink>
</div>
```

The repetition of code makes it harder to maintain and scale. 



## ToDo:
✅ `NavMenu.razor` should be refactored to use a new `MenuItem` component.