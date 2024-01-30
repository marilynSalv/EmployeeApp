export interface EmployeeBaseDto {
  email: string;
  firstName: string;
  lastName: string;
  zipCode: string;
  isManager: boolean;
  companyId: number | null;
  managerId: number | null;
}

export interface EmployeeManagementDto extends EmployeeBaseDto{
    id: number;
    companyName: string;
    managerFirstName: string;
    managerLastName: string;
}

export interface HierarchyType {
    description?: string;
    hierarchyTypeKey?: string;
}

export interface UpdateEmployeeDto extends EmployeeBaseDto {
  id: number;
}


