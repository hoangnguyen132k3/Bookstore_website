import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; // Để dùng các directive như *ngIf, *ngFor
import { Router } from '@angular/router'; // Import Router để điều hướng
import { NavbarComponent } from '../../../../core/component/navbar/navbar.component';
import { FooterComponent } from '../../../../core/component/footer/footer.component'; 


@Component({
  selector: 'app-register',
  standalone: true, // Đảm bảo đây là một standalone component
  imports: [CommonModule, ReactiveFormsModule, NavbarComponent, FooterComponent], // Import NavbarComponent
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) {
    // Tạo một form group cho việc đăng ký
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]], // Tên người dùng
      email: ['', [Validators.required, Validators.email]], // Email
      password: ['', [Validators.required, Validators.minLength(6)]], // Mật khẩu
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]] // Xác nhận mật khẩu
    });
  }

  // Thêm phương thức onRegister để xử lý việc gửi form
  onRegister() {
    if (this.registerForm.valid) {
      const formData = this.registerForm.value;
      if (formData.password !== formData.confirmPassword) {
        console.error('Passwords do not match!');
        return;
      }
      console.log('Form submitted:', formData);
      // Thêm logic xử lý API đăng ký tại đây
    } else {
      console.log('Form is invalid');
    }
  }

  // Phương thức điều hướng sang trang đăng nhập
  goToLogin() {
    this.router.navigate(['/login']);
  }
}
