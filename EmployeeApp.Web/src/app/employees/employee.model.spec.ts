import { Employee } from './employee.model';

describe('Employee', () => {
  it('should create an instance', () => {
    const emp: Employee = {
      firstName: "Test",
      lastName: "test",
      email: "test",
    };
    expect(emp).toBeTruthy();
  });
});
