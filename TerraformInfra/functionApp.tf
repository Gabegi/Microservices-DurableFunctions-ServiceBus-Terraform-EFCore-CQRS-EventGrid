resource "azurerm_windows_function_app" "functionapp-compute" {
  name                = "dionysos-functionapp-compute-${var.environment}"
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
  location            = azurerm_resource_group.infrastructure-rg.location

  storage_account_name       = azurerm_storage_account.strg-account-compute.name
  storage_account_access_key = azurerm_storage_account.strg-account-compute.primary_access_key
  service_plan_id            = azurerm_service_plan.asp-functionapp.id

  # virtual_network_subnet_id = azurerm_subnet.subnet-1.id

  site_config {}

  app_settings = {
    APPINSIGHTS_INSTRUMENTATIONKEY          = azurerm_application_insights.application_insights_functionapp.instrumentation_key
    APPLICATIONINSIGHTS_CONNECTION_STRING   = azurerm_application_insights.application_insights_functionapp.connection_string
    serviceBusConnectionString              = azurerm_servicebus_namespace.servicebus-namespace.default_primary_connection_string
    sqlDbConnectionString                   = var.sqlDbConnectionString
    }

}

resource "azurerm_windows_function_app" "functionapp-routing" {
  name                = "dionysos-functionapp-routing-${var.environment}"
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
  location            = azurerm_resource_group.infrastructure-rg.location

  storage_account_name       = azurerm_storage_account.strg-account-compute.name
  storage_account_access_key = azurerm_storage_account.strg-account-compute.primary_access_key
  service_plan_id            = azurerm_service_plan.asp-functionapp.id

  # virtual_network_subnet_id = azurerm_subnet.subnet-4.id

  site_config {}

  app_settings = {
    APPINSIGHTS_INSTRUMENTATIONKEY          = azurerm_application_insights.application_insights_functionapp.instrumentation_key
    APPLICATIONINSIGHTS_CONNECTION_STRING   = azurerm_application_insights.application_insights_functionapp.connection_string
    serviceBusConnectionString              = azurerm_servicebus_namespace.servicebus-namespace.default_primary_connection_string
    }

}

resource "azurerm_application_insights" "application_insights_functionapp" {
  name                = "dionysos-appinsights-functionapp-${var.environment}"
  location            = azurerm_resource_group.infrastructure-rg.location
  resource_group_name = azurerm_resource_group.infrastructure-rg.name
  application_type    = "web"
}

# resource "azurerm_private_endpoint" "pe-functionapp" {
#   name                = "${azurerm_windows_function_app.functionapp-compute.name}-endpoint"
#   location            = azurerm_resource_group.infrastructure-rg.location
#   resource_group_name = azurerm_resource_group.infrastructure-rg.name
#   subnet_id           = azurerm_subnet.subnet-1.id
  

#   private_service_connection {
#     name                           = "${azurerm_windows_function_app.functionapp-compute.name}-privateconnection"
#     private_connection_resource_id = azurerm_windows_function_app.functionapp-compute.id
#     subresource_names = ["sites"]
#     is_manual_connection = false
#   }
# }
