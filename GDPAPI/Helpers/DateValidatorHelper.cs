using GDPAPI.Models.EnumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Helpers {
    public class DateValidatorHelper {
        public static ResultEnum compareTwoDates(DateTime currentDate1, DateTime currentDate2) {
            if (currentDate1 == null || currentDate2 == null) { return ResultEnum.ERROR; }
            DateTime date1 = currentDate1;
            DateTime date2 = currentDate2;
            if (date1.Year < date2.Year) {
                return ResultEnum.SMALLER;
            } else if (date1.Year > date2.Year) {
                return ResultEnum.GREATER;
            } else {
                if (date1.Month < date2.Month) {
                    return ResultEnum.SMALLER;
                } else if (date1.Month > date2.Month) {
                    return ResultEnum.GREATER;
                } else {
                    if (date1.Date < date2.Date) {
                        return ResultEnum.SMALLER;
                    } else if (date1.Date > date2.Date) {
                        return ResultEnum.GREATER;
                    } else {
                        return ResultEnum.EQUAL;
                    }
                }
            }
        }
    }
}
