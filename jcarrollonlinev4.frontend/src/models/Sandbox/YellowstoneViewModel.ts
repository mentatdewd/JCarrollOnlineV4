import { IModelBase } from "../IModelBase";
import { ImageFileMetadata } from "./ImageFileMetaData";

export interface YellowstoneModel extends IModelBase {
  ImageFiles: ImageFileMetadata[];
}
