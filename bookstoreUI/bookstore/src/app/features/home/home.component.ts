import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from '../../core/component/navbar/navbar.component';
import { FooterComponent } from '../../core/component/footer/footer.component'; 
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  imports: [CommonModule, FormsModule, NavbarComponent, FooterComponent]
})
export class HomeComponent {
  categories = [
    { name: 'Kinh Dị', image: 'https://png.pngtree.com/png-clipart/20231024/original/pngtree-halloween-design-element-scary-skull-for-greeting-card-png-image_13402697.png' },
    { name: 'Nấu Ăn', image: 'https://png.pngtree.com/png-clipart/20220903/ourmid/pngtree-chef-hat-and-cooking-logo-png-image_6136205.png' },
    { name: 'Lịch Sử', image: 'https://dongphuchaianh.com/wp-content/uploads/2024/04/logo-ao-lop-chuyen-su-history.jpg' },
    { name: 'Thiếu Nhi', image: 'https://www.logoground.com/uploads/2017121722017-12-304184255kid%20logo.jpg' },
    { name: 'Tôn Giáo', image: 'https://png.pngtree.com/png-vector/20220520/ourmid/pngtree-abstract-religious-logo-of-christian-cross-linear-church-symbol-vector-png-image_46298254.jpg' },
    { name: 'Trinh Thám', image: 'https://inkythuatso.com/uploads/thumbnails/800/2021/12/logo-trinh-sat-doan-inkythuatso-22-13-59-46.jpg' }
  ];

  flashSales = [
    { name: 'Vì cậu là bạn nhỏ của tớ', discount: 40, price: 12, originalPrice: 20, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Sắc màu văn hoá', discount: 25, price: 8.6, originalPrice: 11.5, image: 'https://png.pngtree.com/thumb_back/fw800/background/20230611/pngtree-an-empty-bookshop-stacked-with-books-image_2924924.jpg' },
    { name: 'Địa ngục tầng thứ 19', discount: 30, price: 28, originalPrice: 40, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Hạnh phúc trong tay', discount: 20, price: 32, originalPrice: 40, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Vì cậu là bạn nhỏ của tớ', discount: 40, price: 12, originalPrice: 20, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Sắc màu văn hoá', discount: 25, price: 8.6, originalPrice: 11.5, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Địa ngục tầng thứ 19', discount: 30, price: 28, originalPrice: 40, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Hạnh phúc trong tay', discount: 20, price: 32, originalPrice: 40, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Vì cậu là bạn nhỏ của tớ', discount: 40, price: 12, originalPrice: 20, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Sắc màu văn hoá', discount: 25, price: 8.6, originalPrice: 11.5, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Địa ngục tầng thứ 19', discount: 30, price: 28, originalPrice: 40, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Hạnh phúc trong tay', discount: 20, price: 32, originalPrice: 40, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' }
  ];

  constructor(private router: Router) {}
  proceedToProductDetail() {
    this.router.navigate(['/product-detail']);
  }
}
