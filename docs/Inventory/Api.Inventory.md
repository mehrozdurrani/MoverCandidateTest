# Add Inventory Item

## Request

```js
POST Inventory/AddInventoryItem
```

```json
{
    "sku" : "Gant-MV-B-L",
    "description": "A beautiful gant blue V-neck t-shirt for youngsters",
    "quantity" : 2
}
```

## Response
*For Successful Inventory Item Insertion*
```js
200 OK
```

# Remove Inventory Quantity

## Request
```js
PUT Inventory/RemoveInventoryItem
```
```json
{
  "sku" : "Gant-MV-B-L",
  "quantity" : 1
}
```

## Response
*For Succesfully Removing Quantity*
```js
200 OK
```

*For Item Not Found*
```js
204 No Content
```

Refer [Sku Format Information](/docs/Inventory/Sku.format.md)

# List All Inventory Items

## Request
```js
GET Inventory/GetInventoryList
```

## Response

```json
{
  "items": [
    {
      "sku": "Gant-MV-B-L",
      "description": "A beautiful gant blue V-neck t-shirt for youngsters",
      "quantity": 1
    }
  ]
}
```