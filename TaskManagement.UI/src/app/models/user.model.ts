export interface User {
  id: number;
  firstName: string;
  lastName: string;
  username: string;
  password: string; // Ensure to hash this in production!
  companyId: number;
  isAdmin: boolean;
}
