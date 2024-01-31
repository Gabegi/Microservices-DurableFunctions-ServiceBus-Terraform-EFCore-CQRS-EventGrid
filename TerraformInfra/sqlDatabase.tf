resource "azurerm_mssql_server" "sql-server-data" {
  name                         = "dionysos-sqlserver-${var.environment}"
  resource_group_name          = azurerm_resource_group.infrastructure-rg.name
  location                     = azurerm_resource_group.infrastructure-rg.location
  version                      = "12.0"
  administrator_login          = "${var.sql-username}"
  administrator_login_password = "${var.sql-password}"
}

resource "azurerm_mssql_database" "sql-database" {
  name           = "dionysos-sql-database-${var.environment}"
  server_id      = azurerm_mssql_server.sql-server-data.id
  sku_name       = "GP_S_Gen5_1"
  min_capacity   = 0.5
  auto_pause_delay_in_minutes = -1
}

## not enough rights in AD for the SP to run this (to be done manually)
# resource "azurerm_role_assignment" "sp-reader-sqlserver" {
#   scope                = azurerm_mssql_server.sql-server-data.id
#   role_definition_name = "Reader"
#   principal_id         = data.azurerm_client_config.example.object_id
# }
