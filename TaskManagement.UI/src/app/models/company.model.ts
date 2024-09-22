// src/app/models/company.model.ts
export interface Company {
  id?: number; // Optional for new companies
  name: string;
  userLimit: number;
  projectLimit: number;
  activeUntil: Date;
}
