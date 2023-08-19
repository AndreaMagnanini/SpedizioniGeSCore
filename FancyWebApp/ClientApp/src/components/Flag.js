import React from 'react';
import {
    AE,
    AT,
    AU,
    AZ,
    BE,
    BH,
    BR,
    CA,
    CN,
    DE, ES,
    FR,
    GB,
    HU,
    IT, JP,
    MC,
    ME,
    NL, QA,
    RU,
    SA, SG,
    US,
    MA,
    ZA,
    SE,
    KR,
    MY,
    TR,
    CH,
    AR
} from "country-flag-icons/react/3x2";
import {makeStyles} from "@material-ui/core";
const useStyles = makeStyles({
    flag: {
        height: "30px",
    }
});
function Flag({country}) {
    const classes = useStyles();

    switch (country) {
        case "Malaysia":
            return <MY title={country} className={classes.flag}></MY>;
        case "Switzerland":
            return <CH title={country} className={classes.flag}></CH>;
        case "Turkey":
            return <TR title={country} className={classes.flag}></TR>;
        case "Argentina":
            return <AR title={country} className={classes.flag}></AR>;
        case "Korea":
            return <KR title={country} className={classes.flag}></KR>;
        case "Sweden":
            return <SE title={country} className={classes.flag}></SE>;
        case "South Africa":
            return <ZA title={country} className={classes.flag}></ZA>;
        case "Morocco":
            return <MA title={country} className={classes.flag}></MA>;
        case "USA":
        case "United States":
            return <US title={country} className={classes.flag}></US>;
        case "Australia":
            return <AU title={country} className={classes.flag}></AU>;
        case "Italy":
            return <IT title={country} className={classes.flag}></IT>;
        case "Germany":
            return <DE title={country} className={classes.flag}></DE>;
        case "Austria":
            return <AT title={country} className={classes.flag}></AT>;
        case "Hungary":
            return <HU title={country} className={classes.flag}></HU>;
        case "France":
            return <FR title={country} className={classes.flag}></FR>;
        case "United Kingdom":
        case "UK":
            return <GB title={country} className={classes.flag}></GB>;
        case "Mexico":
            return <ME title={country} className={classes.flag}></ME>;
        case "Bahrain":
            return <BH title={country} className={classes.flag}></BH>;
        case "Canada":
            return <CA title={country} className={classes.flag}></CA>;
        case "Belgium":
            return <BE title={country} className={classes.flag}></BE>;
        case "Netherlands":
            return <NL title={country} className={classes.flag}></NL>;
        case "Russia":
            return <RU title={country} className={classes.flag}></RU>;
        case "China":
            return <CN title={country} className={classes.flag}></CN>;
        case "UAE":
        case "United Arab Emirates":
            return <AE title={country} className={classes.flag}></AE>;
        case "Brazil":
            return <BR title={country} className={classes.flag}></BR>;
        case "Azerbaijan":
            return <AZ title={country} className={classes.flag}></AZ>;
        case "Monaco":
            return <MC title={country} className={classes.flag}></MC>;
        case "Saudi Arabia":
            return <SA title={country} className={classes.flag}></SA>;
        case "Spain":
            return <ES title={country} className={classes.flag}></ES>;
        case "Singapore":
            return <SG title={country} className={classes.flag}></SG>;
        case "Qatar":
            return <QA title={country} className={classes.flag}></QA>;
        case "Japan":
            return <JP title={country}></JP>;
        default:
            return null;
    }
}

const isEuropeanLocation = (country) => {
    switch (country) {
        case "Italy":
        case "Germany":
        case "Austria":
        case "Hungary":
        case "France":
        case "United Kingdom":
        case "Belgium":
        case "Netherlands":
        case "Monaco":
        case "Spain":
        case "Portugal":
        case "Turkey":
            return true;
        default:
            return false;
    }
}
export {Flag, isEuropeanLocation};