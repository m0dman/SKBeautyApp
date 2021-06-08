import { IBranch } from "../interfaces/ibranch";


export class Branch  implements IBranch {
  id: number  = 0;
  name: string = '';
  address: string = '';
}
