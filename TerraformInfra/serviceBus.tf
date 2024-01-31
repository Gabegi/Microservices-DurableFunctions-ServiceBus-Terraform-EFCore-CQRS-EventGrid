resource "azurerm_servicebus_namespace" "servicebus-namespace" {
  name                = "dionysos-servicebus-namespace-${var.environment}"
  location            = azurerm_resource_group.infrastructure-rg.location
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
  sku                 = "Standard"
  capacity            = 0
}

resource "azurerm_servicebus_queue" "servicebus-queue" {
  name         = "dionysos-servicebus-queue"
  namespace_id = azurerm_servicebus_namespace.servicebus-namespace.id

  enable_partitioning = true
}
