# Shopify GraphQL Reference Notes

GraphQL is a query language for APIs that allows you to request exactly the data you need, and nothing more. Shopify strongly recommends using its GraphQL APIs (Admin API and Storefront API) over REST due to better performance, efficiency, and predictable data structures.

## GraphQL Basics

Unlike REST, which uses multiple endpoints (URLs) for different resources, GraphQL relies on a **single endpoint**. You interact with it using two main operation types:

*   **Queries**: Used to fetch or read data (equivalent to REST `GET`).
*   **Mutations**: Used to create, update, or delete data (equivalent to REST `POST`, `PUT`, `DELETE`).
*   **Edges and Nodes**: Standard structure in Shopify's GraphQL for paginated lists. A list returns `edges` (the connection), which contain a `node` (the actual object/item), and a `cursor` (for pagination).

---

## Shopify GraphQL Setup & Endpoints

*   **Admin API Endpoint**: `https://{store-name}.myshopify.com/admin/api/{api-version}/graphql.json`
*   **Storefront API Endpoint**: `https://{store-name}.myshopify.com/api/{api-version}/graphql.json`
*   **Authentication**: Passed in the headers.
    *   Admin API: `X-Shopify-Access-Token: {your_admin_access_token}`
    *   Storefront API: `X-Shopify-Storefront-Access-Token: {your_storefront_access_token}`

---

## Common Shopify GraphQL Operations

Here are frequent queries and mutations used when interacting with Shopify.

### 1. Fetching Basic Shop Information (Query)
A simple query to get the store's name and primary domain.

```graphql
query {
  shop {
    name
    primaryDomain {
      url
      host
    }
  }
}
```

### 2. Fetching a List of Products (Query)
Demonstrates how to fetch multiple items using the `edges` and `node` structure, retrieving exactly the fields needed (ID, Title, and Handle).

```graphql
query {
  products(first: 5) {
    edges {
      node {
        id
        title
        handle
        status
      }
    }
  }
}
```

### 3. Fetching a Single Product by ID (Query)
How to look up a specific resource using its unique Global ID.

```graphql
query {
  product(id: "gid://shopify/Product/1234567890") {
    title
    vendor
    variants(first: 5) {
      edges {
        node {
          id
          price
          title
        }
      }
    }
  }
}
```

### 4. Creating a Product (Mutation)
Mutations change data. They require input variables and allow you to specify what data you want returned after the change is made.

```graphql
mutation {
  productCreate(input: {
    title: "New Awesome T-Shirt",
    productType: "Apparel",
    vendor: "My Brand"
  }) {
    product {
      id
      title
    }
    userErrors {
      field
      message
    }
  }
}
```

### 5. Updating an Order's Tags (Mutation)
A common task is appending or removing tags from an order or product.

```graphql
mutation {
  tagsAdd(
    id: "gid://shopify/Order/9876543210", 
    tags: ["VIP_Customer", "Urgent"]
  ) {
    node {
      id
    }
    userErrors {
      field
      message
    }
  }
}
```

## Useful Tools
*   **GraphiQL Explorer**: Shopify provides a GraphiQL app (Shopify App Store) which is an interactive, in-browser IDE for testing and writing GraphQL queries against your live store data.
*   **Shopify CLI**: You can use `shopify api` commands or launch local GraphiQL instances during app development.