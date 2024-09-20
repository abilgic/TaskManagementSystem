// src/app/models/company.model.ts

export interface Company {
  id: number;
  name: string;
  address?: string;  // Optional properties
  email?: string;
  phone?: string;
  establishedDate?: Date;
  projectLimit: number;   // Add the projectLimit property
  userLimit: number;      // Add the userLimit property
  activeUntil: Date;      // Add activeUntil property if needed
  projects: any[];        // Add projects if relevant
  users: any[];           // Add users if relevant
}
