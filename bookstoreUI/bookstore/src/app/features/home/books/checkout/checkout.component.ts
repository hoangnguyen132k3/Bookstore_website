import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from '../../../../core/component/navbar/navbar.component';
import { FooterComponent } from '../../../../core/component/footer/footer.component'; 

@Component({
  selector: 'app-checkout',
  standalone: true,  // Đánh dấu component là standalone
  imports: [CommonModule, FormsModule, ReactiveFormsModule,NavbarComponent,FooterComponent], // Import các module cần thiết
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  checkoutForm: FormGroup;
  cartItems = [
    { name: 'Alice ở xứ sở diệu kỳ', price: 65, quantity: 4, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Địa Ngục Tầng Thứ 19', price: 100, quantity: 2, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Địa Ngục Tầng Thứ 12', price: 150, quantity: 3, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' }
  ];
  paymentMethod = 'cod'; // Default: Cash on Delivery

  constructor(private router: Router,private fb: FormBuilder) {
    this.checkoutForm = this.fb.group({
      fullName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      commune: ['', Validators.required],
      province: ['', Validators.required],
      city: ['', Validators.required],
      streetAddress: ['', Validators.required],
    });
    
  }
  proceedToCart() {
    this.router.navigate(['/cart']);
  }
  

  get subtotal(): number {
    return this.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  }

  get totalQuantity(): number {
    return this.cartItems.reduce((sum, item) => sum + item.quantity, 0);
  }

  onSubmit() {
    if (this.checkoutForm.valid) {
      alert('Đặt hàng thành công!');
      console.log('Order Details:', this.checkoutForm.value, 'Payment:', this.paymentMethod);
    } else {
      alert('Vui lòng điền đầy đủ thông tin.');
    }
  }
}
