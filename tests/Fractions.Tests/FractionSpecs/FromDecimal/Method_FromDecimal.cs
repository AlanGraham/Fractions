﻿using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.FromDecimal {

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_0_decimal_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDecimal(decimal.Zero);
        }

        [Test]
        public void Soll_der_Wert_danach_0_sein() {
            _fraction.Should().Be(Fraction.Zero);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_minus_1_decimal_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDecimal(decimal.MinusOne);
        }

        [Test]
        public void Soll_der_Wert_danach_minus_1_sein() {
            _fraction.Should().Be(new Fraction(-1, 1));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_1_decimal_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDecimal(decimal.One);
        }

        [Test]
        public void Soll_der_Wert_danach_1_sein() {
            _fraction.Should().Be(new Fraction(1, 1));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_1_Komma_345_decimal_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDecimal(1.345m);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_269_haben() {
            _fraction.Numerator.Should().Be(new BigInteger(269));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_200_haben() {
            _fraction.Denominator.Should().Be(new BigInteger(200));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_decimal_MaxValue_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDecimal(decimal.MaxValue);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_decimal_MaxValue_haben() {
            _fraction.Numerator.Should().Be(new BigInteger(decimal.MaxValue));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_1_haben() {
            _fraction.Denominator.Should().Be(new BigInteger(1));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_decimal_MinValue_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDecimal(decimal.MinValue);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_minus_decimal_MaxValue_haben() {
            _fraction.Numerator.Should().Be(BigInteger.Negate(new BigInteger(decimal.MaxValue)));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_1_haben() {
            _fraction.Denominator.Should().Be(new BigInteger(1));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_1_Drittel_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDecimal(1.0m / 3.0m);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_3333333333333333333333333333_haben() {
            _fraction.Numerator.Should().Be(BigInteger.Parse("3333333333333333333333333333"));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_10000000000000000000000000000_haben() {
            _fraction.Denominator.Should().Be(BigInteger.Parse("10000000000000000000000000000"));
        }

        [Test]
        public void Soll_der_Bruch_den_Wert_0_33333333333333_haben() {
            _fraction.ToDecimal().Should().Be(1.0m / 3.0m);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_Decimaltestzahlen_erzeugt_wird : Spec {
        private static IEnumerable<TestCaseData> TestCaseSource {
            get {
                yield return new TestCaseData(10000000000000000000000000000.0m);
                yield return new TestCaseData(100000000000000.0m);
                yield return new TestCaseData(100000000000000.00000000000000m);
                yield return new TestCaseData(123456789.0m);
                yield return new TestCaseData(0.123456789m);
                yield return new TestCaseData(0.000000000123456789m);
                yield return new TestCaseData(4294967295.0m);
                yield return new TestCaseData(18446744073709551615.0m);
                yield return new TestCaseData(7.9228162514264337593543950335m);
            }

        }

        [Test, TestCaseSource(nameof(TestCaseSource))]
        public void Soll_der_Bruch_nach_der_Rueckumwandlung_zu_decimal_den_selben_Wert_haben(decimal value) {
            var fraction = Fraction.FromDecimal(value);

            fraction.ToDecimal().Should().Be(value);
        }
    }
}