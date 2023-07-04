import ShipmentCard from "../components/ShipmentCard";
import {makeStyles, Typography, useTheme} from "@material-ui/core";
import {useFetch} from "./useFetch";
import CircularProgress from "../components/CircularProgress";
import {useMediaQuery} from "@mui/material";

const useStyles = makeStyles({
    titleWrapper: {
        width: "100%",
        display: "flex",
        alignItems: "center",
        gap: "20px",
        paddingTop: "10px",
        paddingBottom: "10px",
        position: "fixed",
        backgroundColor: "#212121",
        zIndex: 2,
        boxShadow: "0px 8px 8px #21212180"
    },
    title: {
        textAlign: "left",
        color: "#D41217",
    },
    pageRoot: {
        display: "flex",
        flexDirection: "column",
        height:"100%",
        marginRight: "10px",
        marginLeft: "10px"
    },
});
function Home({year}) {
    const [shipments, isLoading] = useFetch(year);
    const theme = useTheme();
    const classes = useStyles();
    const isMatch = useMediaQuery(theme.breakpoints.down('lg'))

    // Subset of props, to illustrate the idea.
    const config = isMatch ? {height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px", marginRight: "16px", marginLeft: "16px"}
        : {height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px", marginRight: "25px", marginLeft: "25px"};
    return (
        <div className={classes.pageRoot}>
            <div className={classes.titleWrapper}>
                <Typography variant="h4" className={classes.title}>
                    Shipments
                </Typography>
                {isLoading? <CircularProgress className={classes.loader}></CircularProgress> : null}
            </div>
            <div style={{ width: "100%", overflow: "auto", display: "flex" , paddingTop: "62px"}}>
                {shipments.map((shipment) => (
                    <div style={config}>
                        <ShipmentCard shipment={shipment}></ShipmentCard>
                    </div>
                ))}
            </div>
        </div>
    );
}


export default Home;