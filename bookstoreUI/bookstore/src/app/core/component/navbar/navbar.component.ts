import { Component } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  standalone: true, // Sử dụng standalone component
  imports: [CommonModule, RouterModule, FormsModule] // Import các module cần thiết
})
export class NavbarComponent {
  searchTerm: string = '';

  isLoggedIn = false; // Kiểm tra trạng thái đăng nhập
  showUserMenu = false; // Điều khiển hiển thị menu người dùng

  constructor(private router: Router) {}

  // Tìm kiếm
  search() {
    if (this.searchTerm.trim()) {
      this.router.navigate(['/search'], { queryParams: { q: this.searchTerm } });
    }
  }

  // Toggle menu người dùng
  toggleUserMenu() {
    this.showUserMenu = !this.showUserMenu;
  }

  // Điều hướng đến trang
  goToPage(path: string) {
    this.router.navigate([path]);
    this.showUserMenu = false; // Đóng menu sau khi điều hướng
  }

  // Đăng xuất
  logout() {
    this.isLoggedIn = false;
    this.router.navigate(['/login']);
    this.showUserMenu = false;
  }
  
  
  // Đóng menu sau khi chọn một tùy chọn
  closeMenu() {
    this.showUserMenu = false;
  }
}
