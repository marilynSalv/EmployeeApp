import { EmployeeManagementDto } from './employee.model';

describe('Employee', () => {
  it('should create an instance', () => {
    const emp: EmployeeManagementDto = {
      firstName: "Test",
      lastName: "test",
      email: "test",
    };
    expect(emp).toBeTruthy();
  });
});
