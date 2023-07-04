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
    US
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
export default Flag;