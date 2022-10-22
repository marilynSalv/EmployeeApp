import { EmployeeManagementDto } from './employee.model';

describe('Employee', () => {
  it('should create an instance', () => {
    const emp: EmployeeManagementDto = {
      id: 1,
      firstName: "Test",
      lastName: "test",
      email: "test",
      companyId: null,
      managerId: 1,
      isManager: false,
      zipCode: "33613",
      managerFirstName: "Ted",
      managerLastName: "Teddy",
      companyName: "XYZ",
    };
    expect(emp).toBeTruthy();
  });
});
