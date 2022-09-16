export class Employee {
    id: number = 0;
    firstName: string = '';
    lastName: string= '';
    email: string= '';
    companyId: number | null = null;
    managerId: number | null = null;
    isManager: boolean = false;
    zipCode: string = '';

}

export interface HierarchyType {
    description?: string;
    hierarchyTypeKey?: string;
  }
