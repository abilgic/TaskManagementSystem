
// src/app/models/company.spec.ts
import { Company } from './company.model';

describe('Company', () => {
  it('should create a company object', () => {
    const company: Company = {
      id: 1,
      name: 'Test Company',
      userLimit: 10,
      projectLimit: 5,
      activeUntil: new Date() 
    };

    expect(company.name).toBe('Test Company');
    expect(company.userLimit).toBe(10);
    expect(company.projectLimit).toBe(5);
  });
});
