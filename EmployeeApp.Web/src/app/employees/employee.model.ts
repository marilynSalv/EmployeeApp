export interface EmployeeManagementDto extends UpdateEmployeeDto{
    companyName: string;
    managerFirstName: string;
    managerLastName: string;
}

export interface HierarchyType {
    description?: string;
    hierarchyTypeKey?: string;
}

export interface EmployeeBaseDto {
  email: string;
  firstName: string;
  lastName: string;
  zipCode: string;
  isManager: boolean;
  companyId: number | null;
  managerId: number | null;
}

export interface UpdateEmployeeDto extends EmployeeBaseDto {
  id: number;
}


