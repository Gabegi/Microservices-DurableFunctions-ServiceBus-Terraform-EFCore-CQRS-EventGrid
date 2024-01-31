resource "azurerm_eventgrid_topic" "eventgrid-topic" {
  name                = "dionysos-eventgrid-topic-${var.environment}"
  location            = azurerm_resource_group.infrastructure-rg.location
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
}

## subscription == https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/eventgrid_event_subscription
## once events are created, subscriptions to events must be defined