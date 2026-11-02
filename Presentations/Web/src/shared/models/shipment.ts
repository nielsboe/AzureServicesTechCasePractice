import { Product } from "./product";

export class Shipment {
  constructor(
    public Id : number,
    public InternalProductId : number,
    public OrderId : number,
    public ShipmentAddress : string,
    public Products : Array<Product>,
    public ShipmentDate : Date
  ) {}
}