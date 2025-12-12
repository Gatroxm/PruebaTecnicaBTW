
export interface User {
  id: number;
  name: string;
  email: string;
  role: string;
  isActive: boolean;
}

// Create User DTO
export interface CreateUserRequest {
  name: string;
  email: string;
  isAdmin: boolean;
}
