export class Blobinfo {
    propertyId:     string | undefined;
    propertyName:   string | undefined;
    features:       string[] | undefined;
    highlights:     string[] | undefined;
    transportation: Transportation[] | undefined;
    spaces:         Space[] | undefined;
}

export class Space {
    spaceId:   string | undefined;
    spaceName: string | undefined;
    rentRoll:  RentRoll[] | undefined;
}

export class RentRoll {
    month: string | undefined;
    rent:  number | undefined;
}



export interface Transportation {
    type:     string;
    line:     null | string;
    distance: string;
    station:  null | string;
}
