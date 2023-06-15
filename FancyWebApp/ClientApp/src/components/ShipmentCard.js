import React from 'react';
import {Card, CardActions, CardContent, CardHeader, makeStyles, ThemeProvider, Typography} from "@material-ui/core";
import FerrariTheme from "../styles/FerrariTheme";

const useStyles = makeStyles({
    card: {
        border: "2.5px solid #000000",
        borderRadius: 10,
        width: "400px",
        height: "700px",
        transition: "transform 0.15s ease-in-out",
        '&:hover': {
            boxShadow: "10px 10px black",
            transform: "scale3d(1.05, 1.05, 1)",
            marginRight: ""
        }
    },
    cardHeader: {
        backgroundColor: "#D41217",
        height: "100px"
    },
    summary: {
        backgroundColor: "#eeeeee",
    },
    commands:{

    }
});
function ShipmentCard({shipment}) {
    const classes = useStyles();
    return (
        <ThemeProvider theme={FerrariTheme}>
            <Card className={classes.card}>
                <CardHeader className={classes.cardHeader}>
                    <Typography>props.shipment.Code</Typography>
                </CardHeader>
                <CardContent className={classes.summary}>

                </CardContent>
                <CardActions className={classes.commands}>

                </CardActions>
            </Card>
        </ThemeProvider>
    );
}

export default ShipmentCard;