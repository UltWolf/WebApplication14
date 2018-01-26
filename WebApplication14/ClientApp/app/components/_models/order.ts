import { User } from './user';
import { Product } from './product';

export class  Order {
         orderId:number;
         idProduct:number; 
         product:Product; 
         DateOfOrder:Date;
         UserId:string; 
         User: User; 
         Count:number; 
         IsConfirm:boolean;
    }

