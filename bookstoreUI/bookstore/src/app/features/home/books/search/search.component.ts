import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from '../../../../core/component/navbar/navbar.component';
import { FooterComponent } from '../../../../core/component/footer/footer.component'; 

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
  imports: [CommonModule, FormsModule,NavbarComponent,FooterComponent]
})
export class SearchComponent {
  flashSales = [
    { name: 'Vì cậu là bạn nhỏ của tớ', discount: 40, price: 12, originalPrice: 20, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
    { name: 'Sắc màu văn hoá', discount: 25, price: 8.6, originalPrice: 11.5, image: 'https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg' },
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
}
