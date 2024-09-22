// src/app/models/company.model.ts

export interface Company {
  id: number;
  name: string;
  address?: string;  // Optional properties
  email?: string;
  phone?: string;
  establishedDate?: Date;
  projectLimit: number;   // Project limit property
  userLimit: number;      // User limit property
  activeUntil: Date;      // Active until property
  projects: any[];        // Relevant projects
  users: any[];           // Relevant users
  adminUserId?: number | null;   // Change to include null
}

