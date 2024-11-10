﻿module "ecr" {
  source = "terraform-aws-modules/ecr/aws"
  version = "2.3.0"

  repository_name = var.repository_name
  
  repository_lifecycle_policy = templatefile(var.lifecycle_policy_file)

  tags = {
    Terraform   = "true"
  }
}