import {Location} from './Location'
export interface Event{
    Description: string;
    Alias: string;
    Location: Location;
    ExtraEU: boolean;
    EventNumber: number;
    Start: Date;
    End: Date;
}