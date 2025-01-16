import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; // Để dùng các directive như *ngIf, *ngFor
import { NavbarComponent } from '../../../../core/component/navbar/navbar.component';
import { FooterComponent } from "../../../../core/component/footer/footer.component"; 
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true, // Đây là standalone component
  imports: [CommonModule, ReactiveFormsModule, NavbarComponent, FooterComponent], // Import NavbarComponent ở đây
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      console.log('Login Successful:', this.loginForm.value);
      // Thêm logic xử lý đăng nhập tại đây
    } else {
      console.log('Login Form is invalid');
    }
  }

  // Phương thức điều hướng đến trang đăng ký
  goToRegister() {
    this.router.navigate(['/register']);
  }
  
}
