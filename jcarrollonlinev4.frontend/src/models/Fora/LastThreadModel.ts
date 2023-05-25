import { ForaGetModel } from "./ForaGetModel";

export interface LastThreadModel {
  UpdatedAt: Date;
  Title?: string;
  PostRoot: number;
  PostNumber: number;
  Author?: string;
  Forum?: ForaGetModel;
}
