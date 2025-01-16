import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { NavbarComponent } from '../../../../core/component/navbar/navbar.component';
import { FooterComponent } from '../../../../core/component/footer/footer.component'; 

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, FormsModule, NavbarComponent, FooterComponent],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  cartItems = [
    {
      name: 'Alice ở xứ sở diệu kỳ',
      price: 65,
      quantity: 1,
      image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg',
    },
    {
      name: 'Địa Ngục Tầng Thứ 19',
      price: 50,
      quantity: 2,
      image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg',
    },
    {
      name: 'Alice ở xứ sở diệu kỳ',
      price: 70,
      quantity: 3,
      image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg',
    },
  ];
  constructor(private router: Router) {}

  // Điều hướng đến trang Checkout
  proceedToCheckout() {
    this.router.navigate(['/checkout']);
  }
  proceedToHome() {
    this.router.navigate(['/']);
  }
}
