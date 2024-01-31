terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = "3.72.0"
    }
  }
}

terraform {
  backend "azurerm" {
    # resource_group_name  = "rg-dionysos-tfstate-dev"
    # storage_account_name = "dionysos00tfstate00dev"
    # container_name       = "tfstate-dev"
    # key                  = "devterraform.tfstate"
  }
}

provider "azurerm" {
  features {
    resource_group {
       prevent_deletion_if_contains_resources = false
     }
  }
}

# data "azurerm_subscription" "primary" {
# }

data "azurerm_client_config" "example" {
}