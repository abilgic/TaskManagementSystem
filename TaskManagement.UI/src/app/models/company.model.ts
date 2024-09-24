// src/app/services/company.service.ts
// src/app/models/company.model.ts
export interface Company {
  id: number;
  name: string;
  userLimit: number;
  projectLimit: number;
  activeUntil: Date;
}

