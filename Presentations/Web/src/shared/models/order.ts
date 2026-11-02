import { Product } from "./product";

export class Order {
  constructor(
    public Id : number,
    public InternalOrderId : number,
    public CustomerName : string,
    public OrderDate : Date,
    public IsShipped : boolean,
    public Products : Array<Product>,
    public TotalOrderPrice : number
  ) {}
}