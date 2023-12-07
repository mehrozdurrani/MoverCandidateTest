# Add Inventory Item

## Request

```js
POST/InventoryItems
```

```json
{
    "sku" : "Gant-MV-B-L",
    "description": "A beautiful gant blue V-neck t-shirt for youngsters",
    "quantity" : 2
}
```

## Response
*For New Record*
```js
201 Created
```

*For Existing Record*
```js
200 OK
```

# Remove Inventory Quantity

## Request
```js
DELETE/InventoryItems/{{sku}}
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

# List All Inventory Items

## Request
```js
GET/InventoryItems
```

## Response

```json
{
  "items": [
    {
      "sku": "Gant-MV-B-L",
      "description": "A beautiful Gant blue V-neck t-shirt for youngsters",
      "quantity": 2
    },
    // More items if available
  ]
}
```

# SKU Format

The inventory items are T-Shirts, and the SKU is based on the following format:

- **Brand**: Gant, Nike, Adidas
- **Style**: Men's Crewneck (MC), Men's V-Neck (MV), Men's Turtleneck (MT)
- **Color**: Red (R), Blue (B), Green (G)
- **Size**: S, M, L, XL, XXL

**SKU Format**: Brand-Style-Color-Size

## Example SKUs:

1. Blue Gant V-Neck Large T-Shirt: `Gant-MV-B-L`
2. Green Adidas Turtleneck Medium T-Shirt: `Adidas-MT-G-M`
