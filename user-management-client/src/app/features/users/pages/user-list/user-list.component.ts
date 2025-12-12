
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../../../core/services/user.service';
import { User } from '../../../../core/models/user.model';
import { UserListTableComponent } from '../../components/user-list-table/user-list-table.component';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule, FormsModule, UserListTableComponent],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {
  users: User[] = [];
  loading = true;

  editingUser: User | null = null;
  editForm = { name: '', email: '' };

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.loading = true;
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Failed to load users', err);
        this.loading = false;
      }
    });
  }

  createUser() {
    const randomId = Math.floor(Math.random() * 1000);
    const split = Math.random() > 0.5;
    const userRequest = {
      name: `User ${randomId}`,
      email: `user${randomId}@example.com`,
      isAdmin: split
    };

    this.userService.createUser(userRequest).subscribe({
      next: () => {
        alert('User created successfully!');
        this.loadUsers();
      },
      error: (err) => {
        console.error('Failed to create user', err);
        alert('Failed to create user. Ensure API is running.');
      }
    });
  }

  onDelete(id: number) {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(id).subscribe({
        next: () => {
          this.loadUsers();
        },
        error: (err) => console.error('Failed to delete user', err)
      });
    }
  }

  onEdit(user: User) {
    this.editingUser = user;
    this.editForm = { name: user.name, email: user.email };
  }

  saveUser() {
    if (!this.editingUser) return;

    const request = {
      id: this.editingUser.id,
      name: this.editForm.name,
      email: this.editForm.email
    };

    this.userService.updateUser(this.editingUser.id, request).subscribe({
      next: () => {
        this.editingUser = null;
        this.loadUsers();
      },
      error: (err) => console.error('Failed to update user', err)
    });
  }

  cancelEdit() {
    this.editingUser = null;
  }
}
